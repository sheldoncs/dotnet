using jwtcore.Data.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace jwtcore.Filter {

    public class AuthenticationFilter: ActionFilterAttribute {


       public override void  OnActionExecuting(ActionExecutingContext context){
               base.OnActionExecuting(context);
               var authenticate = context.ActionArguments["authenticationCreateDto"] as AuthenticateCreateDto;
               bool isValid = true;

               if (authenticate != null){
                    if (string.IsNullOrWhiteSpace(authenticate.Username)) { 
                        isValid = false;               
                        context.ModelState.AddModelError("Username","Username is required!");
                        
                    }
                    if (string.IsNullOrWhiteSpace(authenticate.Password)) { 
                        isValid = false;               
                        context.ModelState.AddModelError("Password","Password is required!");
                    }
               } else  {
                   isValid = false;
                   isValid = false;               
                   context.ModelState.AddModelError("Credentials","Incorrect login!");
               }
               if (!isValid)     
                  context.Result = new BadRequestObjectResult(context.ModelState);
               
        }

        
    }
    
}