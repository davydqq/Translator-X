﻿namespace TB.Menu.Entities;

public class BotMenuCommand
{
    public BotMenuId Id { get; set; }

    public string Name { set; get; }

    public string Description { set; get; }

    public string? CallBackId { set; get; }
}
