package com.javainuse.model;

import com.fasterxml.jackson.annotation.JsonIgnore;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import java.time.LocalDate;

@Entity
@Table(name = "user")
public class DAOUser {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="id")
	private int id;

	@Column(name="username")
	@NotBlank
	private String username;

	@NotBlank
	@Column(name="mail")
	private String mail;

	@NotNull
	@Column(name="birthDate")
	private LocalDate birthDate;

	@NotBlank
	@Column(name="career")
	private String career;

	@NotBlank
	@Column(name="role")
	private String role;

	@NotBlank
	@Column(name="name")
	private String name;

	@NotBlank
	@Column(name="password")
	private String password;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public void setMail(String mail) {
		this.mail = mail;
	}

	public String getMail() {
		return mail;
	}


	public LocalDate getBirthDate() {
		return birthDate;
	}

	public void setBirthDate(LocalDate birthDate) {
		System.out.println(birthDate);
		this.birthDate = birthDate;
	}

	public String getCareer() {
		return career;
	}

	public void setCareer(String career) {
		this.career = career;
	}

	public String getRole() {
		return role;
	}

	public void setRole(String role) {
		this.role = role;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}


	@Override
	public String toString() {
		return "User"+
				"[id=" + id +
				", mail=" + mail +
				", username=" + username +
				", mail=" + mail +
				", birth_date=" + birthDate +
				", career=" + career +
				", role=" + role +
				", name=" + name +
				", password=" + password;
	}
}