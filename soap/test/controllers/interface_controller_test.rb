require 'test_helper'

class InterfaceControllerTest < ActionDispatch::IntegrationTest
  test "should get information" do
    get interface_information_url
    assert_response :success
  end

end
