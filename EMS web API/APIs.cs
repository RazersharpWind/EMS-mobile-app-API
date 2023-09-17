using DataAccess.Data;
using DataAccess.Models;

namespace EMS_web_API;

public static class APIs
{
    public static void ConfigureApi(this WebApplication app)
    {
        //All of the API endpoint mapping
        //Event API routes
        app.MapGet("/Events", GetEvents);
        app.MapGet("/Events/{id}", GetEvent);
        app.MapPost("/Events", CreateEvent);
        app.MapPut("/Events", UpdateEvent);

        //User API routes
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users", CreateUser);
        app.MapPut("/Users", UpdateUser);

        //Login API route
        app.MapPost("/Login", Login);

        //API route that will update the attendee status
        app.MapPost("/UpdateAttendeeStatus", SetAttendeeStatus);
    }

    private static async Task<IResult> GetEvents(IEventData data)
    {
        try
        {
            return Results.Ok(await data.GetEvents());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetEvent(int id, IEventData data)
    {
        try
        {
            var result = await data.GetEvent(id);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> CreateEvent(Event newEvent, IEventData data)
    {
        try
        {
            await data.CreateEvent(newEvent);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateEvent(Event newEvent, IEventData data)
    {
        try
        {
            await data.UpdateEvent(newEvent);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    //user API calls
    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try
        {
            var result = await data.GetUser(id);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> CreateUser(User_with_eID newUser, IUserData data)
    {
        try
        {
            await data.InsertUser(newUser);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(User_with_eID newUser, IUserData data)
    {
        try
        {
            await data.UpdateUser(newUser);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> Login(string email, string password, IUserData data)
    {
        try
        {
            var user = await data.Login(email, password); // Await the task to get the user data
            if (user != null)
            {
                return Results.Ok(user);
            }
            else
            {
                return Results.Unauthorized();
            }
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> SetAttendeeStatus(string email, int eventID, string status, IAttendeeData data)
    {
        try
        {
            await data.SetAttendeeStatus(email, eventID, status);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}