package com.javainuse.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class AuthorizationController {

	@RequestMapping({ "/authorize" })
	public Boolean firstPage() {
			return true;
	}

}