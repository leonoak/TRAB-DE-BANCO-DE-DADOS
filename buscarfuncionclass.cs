public void BuscarFuncionarioPorId(NpgsqlConnection conexao, int id)
{
    string query = "SELECT * FROM funcionarios WHERE id = @id";
    using (var cmd = new NpgsqlCommand(query, conexao))
    {
        cmd.Parameters.AddWithValue("id", id);
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                Console.WriteLine($"Nome: {reader["nome"]}, Cargo: {reader["cargo"]}, Salário: {reader["salario"]}");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }
    }
}
