﻿using DataAccess.Data;
using DataAccess.Models;

namespace EMS_web_API;

public static class APIs
{
    public static void ConfigureApi(this WebApplication app)
    {
        //All of the API endpoint mapping
        app.MapGet("/Events", GetEvents);
        app.MapGet("/Events/{id}", GetEvent);
        app.MapPost("/Events", CreateEvent);
        app.MapPut("/Events", UpdateEvent);
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
}