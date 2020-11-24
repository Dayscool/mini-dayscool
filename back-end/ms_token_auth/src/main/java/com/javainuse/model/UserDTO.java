package com.javainuse.model;

import java.time.LocalDate;

public class UserDTO {
	private int id;
	private String username;
	private String mail;
	private LocalDate birthDate;
	private String career;
	private String name;
	private String password;
	private String role;
	public String getUsername() { return username; 	}

	public void setUsername(String username) { this.username = username; }

	public int getId() { return id;}

	public void setId(int id) { this.id = id; }

	public String getMail() { return mail; 	}

	public void setMail(String mail) { this.mail = mail; }

	public LocalDate getBirthDate() { return birthDate; }

	public void setBirthDate(LocalDate birthDate) { this.birthDate = birthDate; }

	public String getCareer() { return career; 	}

	public void setCareer(String career) { this.career= career; }

	public String getName() { return name; 	}

	public void setName(String name) { this.name = name; }

	public String getRole() { return role; 	}

	public void setRole(String role) { this.role = role; }


	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}
}