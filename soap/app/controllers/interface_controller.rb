require 'httparty'
require 'json'

class InterfaceController < ApplicationController
  soap_service namespace: 'urn:WashOut'

  soap_action "integer_to_string",
              :args   => nil,
              :return => [{:nombre => :string, :color => :string}]
  def integer_to_string
    response = HTTParty.post("https://9185459f-58e6-473e-98e0-82b11db8385a.mock.pstmn.io/gato")
    print(response.body)
    render :soap => JSON.parse(response.body.data)
  end
  
  def information
  end
end
