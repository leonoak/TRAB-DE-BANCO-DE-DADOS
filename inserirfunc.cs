public void CriarFuncionario(NpgsqlConnection conexao, string nome, string cargo, decimal salario)
{
    string query = "INSERT INTO funcionarios (nome, cargo, salario) VALUES (@nome, @cargo, @salario)";
    using (var cmd = new NpgsqlCommand(query, conexao))
    {
        cmd.Parameters.AddWithValue("nome", nome);
        cmd.Parameters.AddWithValue("cargo", cargo);
        cmd.Parameters.AddWithValue("salario", salario);
        cmd.ExecuteNonQuery();
    }
}
