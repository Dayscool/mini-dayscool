var ldap = require('ldapjs');

var ldapServer = 'ldap://172.17.0.1:389';



const serverName = ',dc=dayscool,dc=unal,dc=edu,dc=co';
var user = 'cn=admin' +serverName;
var password = 'admin';

const direccion = 'cn=user' + serverName;

async function createLdapEntry( usuario, contrasena ) {
    var client = ldap.createClient({
		url: ldapServer
    });
	client.bind(user,'admin', function(err) {
		console.log(err)
	})

	var entry = {
		objectclass: ['account', 'simpleSecurityObject'],
		userPassword: contrasena
	};
	
	client.add('uid='+ usuario + direccion, entry ,function(err) {
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
		client.compare("uid=" + usuario + direccion, 'userPassword', contrasena, function (_err, bool) {
			resolve(bool) 
			client.unbind()
		});
	})
	return promise
	
}



export {createLdapEntry, searchUserLdap}