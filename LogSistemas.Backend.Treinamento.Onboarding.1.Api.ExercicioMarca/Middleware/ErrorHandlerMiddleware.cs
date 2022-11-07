using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Resource;
using Newtonsoft.Json;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        //HTTPContext é tudo que tenho sobre requisição, inclusive resposta
        public async Task Invoke(HttpContext context)
        {
            //Call the next middleware in the pipeline
            try
            {
                await _next(context);
            } //if there's an error in this middleware
            catch (ValidationException validationException)
            {  //error from my fluentvalidator are passed as parameter

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;


                var content = new
                {
                    message = ErrorCodes.ME0400,
                    ErrorCode = nameof(ErrorCodes.ME0400), //to print error's code name
                    detail = validationException.Errors
                }; //convert to JSON the errors founded
                string result = JsonConvert.SerializeObject(content);
                //write the errors
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                //todo: fazer tratamento de exceção
            }
        }

    }
}
