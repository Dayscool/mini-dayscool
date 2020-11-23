Rails.application.routes.draw do
  wash_out :interface
  get 'interface/', to: 'interface#consume'
  
  # For details on the DSL available within this file, see https://guides.rubyonrails.org/routing.html
end
