require 'httparty'
require 'json'

class InterfaceController < ApplicationController
  soap_service namespace: 'urn:WashOut'

  soap_action "integer_to_string",
              :args   => nil,
              :return => [{:name => :string, :mail => :string}]
  def integer_to_string
    response = HTTParty.post("http://172.17.0.1:5000/graphql", body: {"query":"{\n  getTeachers{\n    name\n    mail\n  }\n}",variables:"null",operationName:nil})
    print(response.body)
    render :soap => JSON.parse(response.body)["data"]["getTeachers"]
  end
  
  def information
  end
end
