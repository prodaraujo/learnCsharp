using System;
using System.Collections.Generic;

namespace API.Models;

public class Cadastro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Email { get; set; }
}