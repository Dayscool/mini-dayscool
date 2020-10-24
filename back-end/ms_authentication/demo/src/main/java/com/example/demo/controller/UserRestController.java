package com.example.demo.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.RequestParam;

import com.example.demo.entity.User;  
import com.example.demo.service.UserService;

//Indiciamos que es un controlador rest
@RestController
@RequestMapping("/api") //esta sera la raiz de la url, es decir http://127.0.0.1:8080/api/

public class UserRestController {
	
	//Inyectamos el servicio para poder hacer uso de el
	@Autowired
	private UserService userService;

	/*Este método se hará cuando por una petición GET (como indica la anotación) se llame a la url 
	http://127.0.0.1:8080/api/users*/
	@GetMapping("/users")
	public List<User> findAll(){
		//retornará todos los usuarios
		return userService.findAll();
	}
	
	/*Este método se hará cuando por una petición GET (como indica la anotación) se llame a la url + el id de un usuario
	http://127.0.0.1:8080/api/users/1*/
	//@CrossOrigin(origins = "*", methods= {RequestMethod.GET,RequestMethod.PUT,RequestMethod.POST})	
	@GetMapping("/users/{userId}")
	public User getUser(@PathVariable int userId){
		User user = userService.findById(userId);
		if(user == null) {
			throw new RuntimeException("user id not found -"+userId);
		}
		//retornará al usuario con id pasado en la url
		return user;
	}

	/*Este método se hará cuando por una petición GET (como indica la anotación) se llame a la url + el id de un usuario
	http://127.0.0.1:8080/api/users/1*/
	//@CrossOrigin(origins = "*", methods= {RequestMethod.GET,RequestMethod.PUT,RequestMethod.POST})	
	@GetMapping("/users/{username}/{password}")
	public User getUserC(@PathVariable String username, @PathVariable String password){ 

		User id = userService.findByUsernameOrMailAndPassword(username, password);		
		if(id == null) {
			throw new RuntimeException("user id not found -");
		}
		//retornará al usuario con id pasado en la url
		userService.save(id);
		return id;
	}
	
	/*Este método se hará cuando por una petición POST (como indica la anotación) se llame a la url
	http://127.0.0.1:8080/api/users/  */
	@PostMapping("/users")
	public User addUser(@RequestBody User user) {
		System.out.println(user);
		user.setId(0);
		//Este metodo guardará al usuario enviado
		user.setEntryTime(null);
		userService.save(user);
		return user;
	}
	/*Este método se hará cuando por una petición PUT (como indica la anotación) se llame a la url
	http://127.0.0.1:8080/api/users/  */
	
	
	//@CrossOrigin(origins = "*", methods= {RequestMethod.GET,RequestMethod.PUT,RequestMethod.POST})	
	@PutMapping("/users")
	public User updateUser(@RequestBody User user) { 
		userService.save(user);
		
		//este metodo actualizará al usuario enviado
		
		return user;
	}

	//@CrossOrigin(origins = "*", methods= {RequestMethod.GET,RequestMethod.PUT,RequestMethod.POST})	
	@PutMapping("/users/{userId}")
	public User logOut(@PathVariable int userId) { 
		User user = userService.findById(userId);
		if(user == null) {
			throw new RuntimeException("user id not found -"+userId);
		}
		
		userService.updateEntry_time(user);
		return user;
	}
	
	/*Este método se hará cuando por una petición DELETE (como indica la anotación) se llame a la url + id del usuario
	http://127.0.0.1:8080/api/users/1  */
	@DeleteMapping("users/{userId}")
	public String deleteUser(@PathVariable int userId) {
		
		User user = userService.findById(userId);
		
		if(user == null) {
			throw new RuntimeException("user id not found -"+userId);
		}
		
		userService.deleteById(userId);
		
		//Esto método, recibira el id de un usuario por URL y se borrará de la bd.
		return "Deleted user id - "+userId;
	}
	
}