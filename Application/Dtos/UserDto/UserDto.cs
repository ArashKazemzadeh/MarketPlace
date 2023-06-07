﻿namespace Application.Dtos.UserDto;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public List<string> Roles { get; set; }

}