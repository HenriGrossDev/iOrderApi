﻿namespace iOrderApp.Endpoints.Clients;

public record ClientRequest(string Email, string Password, string Name, string Cpf);
