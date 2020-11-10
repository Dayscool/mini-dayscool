var ldap = require('ldapjs');

var ldapServer = 'ldap://172.17.0.1:389';



var user = 'cn=admin,dc=arqsoft,dc=unal,dc=edu,dc=co';
var password = 'admin';



async function createLdapEntry( usuario, contrasena ) {
    var client = ldap.createClient({
		url: ldapServer
    });
	client.bind('cn=admin,dc=arqsoft,dc=unal,dc=edu,dc=co','admin', function(err) {
		console.log(err)
	})

	var entry = {
		objectclass: ['account', 'simpleSecurityObject'],
		userPassword: contrasena
	};
	client.add('uid='+ usuario +',cn=user,dc=arqsoft,dc=unal,dc=edu,dc=co', entry ,function(err) {
			console.log(err)
	});

	client.unbind()
}


async function searchUserLdap(usuario, contrasena) {
    var client = ldap.createClient({
        url: ldapServer
      });

	client.bind(user,password, function(err) {
		console.log(err) 
	})

	var promise = new Promise((resolve, reject)=> {
		client.compare("uid=" + usuario +",cn=user,dc=arqsoft,dc=unal,dc=edu,dc=co", 'uid', usuario, function (_err, bool) {
			resolve(bool) 
			client.unbind()
		});
	})
	return promise
	
}



export {createLdapEntry, searchUserLdap}