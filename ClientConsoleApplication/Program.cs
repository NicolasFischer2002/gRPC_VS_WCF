
try
{
	Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Aplicação iniciada");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\nErro inesperado: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"\nAplicação finalizada");
    Console.ForegroundColor = ConsoleColor.White;
}