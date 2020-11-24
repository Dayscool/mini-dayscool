require 'httparty'
require 'json'
require 'savon'

class InterfaceController < ApplicationController
  soap_service namespace: 'urn:WashOut'

  soap_action "profesores",
              :args   => nil,
              :return => [{:name => :string, :mail => :string}]
  def profesores
    response = HTTParty.post("http://172.17.0.1:5000/graphql", body: {"query":"{\n  getTeachers{\n    name\n    mail\n  }\n}",variables:"null",operationName:nil})
    print(response.body)
    render :soap => JSON.parse(response.body)["data"]["getTeachers"]
  end
  
  def consume
    client = Savon.client(wsdl: 'http://ec2-54-234-177-146.compute-1.amazonaws.com:8080/service/userDetailsWsdl.wsdl')
    response =client.call(:user_details, message: {email: params[:mail]})
    
    render :json => response.body[:user_details_response][:user]
  end
end
