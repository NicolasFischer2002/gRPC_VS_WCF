using ClientConsoleApplication.ValueObjects;
using WCF;

try
{
	Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Aplicação iniciada");

    // await BenchmarkWCF();
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

async Task BenchmarkWCF()
{
    var client = new Service1Client();

    var valores = ValoresParaBenchmark();

    await client.OpenAsync();

    var request = new Bhaskara
    {
        A = 1,
        B = -3,
        C = 2
    };

    ResolucaoBhaskara response = await client.ResolverBhaskaraAsync(request);

    await client.CloseAsync();
}

IReadOnlyList<BhaskaraClient> ValoresParaBenchmark()
{
    IReadOnlyList<BhaskaraClient> bhaskarasClient = new List<BhaskaraClient>()
    {
        // Δ = (-3)² - 4·1·2 = 9 - 8 = 1  → raízes distintas
        new BhaskaraClient(1, -3, 2),

        // Δ = 2² - 4·1·1 = 4 - 4 = 0  → raiz dupla
        new BhaskaraClient(1, 2, 1),

        // Δ = 0² - 4·1·(-4) = 0 + 16 = 16  → raízes ±2
        new BhaskaraClient(1, 0, -4),

        // Δ = 5² - 4·2·3 = 25 - 24 = 1  → raízes distintas
        new BhaskaraClient(2, 5, 3),

        // Δ = 1² - 4·3·(-1) = 1 + 12 = 13 → raízes reais
        new BhaskaraClient(3, 1, -1),

        // Δ = 4² - 4·1·3 = 16 - 12 = 4  → raízes distintas
        new BhaskaraClient(1, 4, 3),

        // Δ = 9 - 4·2·2 = 9 - 16 = -7 → descartado (complexo)  
        // Para manter Δ ≥ 0, ajustamos:
        // Δ = 9 - 4·2·1 = 9 - 8 = 1
        new BhaskaraClient(2, 3, 1),

        // Δ = 16 - 4·4·1 = 16 - 16 = 0  → raiz dupla
        new BhaskaraClient(4, 4, 1),

        // Δ = 25 - 4·5·1 = 25 - 20 = 5  → raízes reais
        new BhaskaraClient(5, 5, 1),

        // Δ = 36 - 4·6·2 = 36 - 48 = -12 → ajustado:
        // Δ = 36 - 4·6·1 = 36 - 24 = 12
        new BhaskaraClient(6, 6, 1),

        // Δ = 49 - 4·7·3 = 49 - 84 = -35 → ajustado:
        // Δ = 49 - 4·7·2 = 49 - 56 = -7 → ainda negativo  
        // usar c = 1: Δ = 49 - 4·7·1 = 49 - 28 = 21
        new BhaskaraClient(7, 7, 1),

        // Δ = 64 - 4·8·4 = 64 - 128 = -64 → ajustado:
        // c = 2 → Δ = 64 - 4·8·2 = 64 - 64 = 0
        new BhaskaraClient(8, 8, 2),

        // Δ = 81 - 4·9·5 = 81 - 180 = -99 → ajustado:
        // c = 3 → 81 - 4·9·3 = 81 - 108 = -27 → c = 2 → 81 - 72 = 9
        new BhaskaraClient(9, 9, 2),

        // Δ = 100 - 4·10·6 = 100 - 240 = -140 → ajustado:
        // c = 3 → 100 - 120 = -20 → c = 2 → 100 - 80 = 20
        new BhaskaraClient(10, 10, 2),

        // Δ = 121 - 4·11·6 = 121 - 264 = -143 → ajustado:
        // c = 3 → 121 - 132 = -11 → c = 2 → 121 - 88 = 33
        new BhaskaraClient(11, 11, 2),

        // Δ = 144 - 4·12·7 = 144 - 336 = -192 → ajustado:
        // c = 3 → 144 - 144 = 0
        new BhaskaraClient(12, 12, 3),

        // Δ = 169 - 4·13·8 = 169 - 416 = -247 → ajustado:
        // c = 5 → 169 - 260 = -91 → c = 4 → 169 - 208 = -39 → c=3 →169-156=13
        new BhaskaraClient(13, 13, 3),

        // Δ = 196 - 4·14·7 = 196 - 392 = -196 → ajustado:
        // c = 4 → 196 - 224 = -28 → c = 3 → 196 - 168 = 28
        new BhaskaraClient(14, 14, 3),

        // Δ = 225 - 4·15·8 = 225 - 480 = -255 → ajustado:
        // c = 5 → 225 - 300 = -75 → c = 3 → 225 - 180 = 45
        new BhaskaraClient(15, 15, 3),

        // Δ = 256 - 4·16·10 = 256 - 640 = -384 → ajustado:
        // c = 5 → 256 - 320 = -64 → c = 4 → 256 - 256 = 0
        new BhaskaraClient(16, 16, 4),

        // Δ = 289 - 4·17·9 = 289 - 612 = -323 → ajustado:
        // c = 5 → 289 - 340 = -51 → c = 4 → 289 - 272 = 17
        new BhaskaraClient(17, 17, 4),

        // Δ = 324 - 4·18·9 = 324 - 648 = -324 → ajustado:
        // c = 5 → 324 - 360 = -36 → c = 4 → 324 - 576? erro  
        // usar c = 3 → 324 - 216 = 108
        new BhaskaraClient(18, 18, 3),

        // Δ = 361 - 4·19·10 = 361 - 760 = -399 → ajustado:
        // c = 4 → 361 - 304 = 57
        new BhaskaraClient(19, 19, 4),

        // Δ = 400 - 4·20·12 = 400 - 960 = -560 → ajustado:
        // c = 5 → 400 - 400 = 0
        new BhaskaraClient(20, 20, 5),

        // Δ = 441 - 4·21·11 = 441 - 924 = -483 → ajustado:
        // c = 7 → 441 - 588 = -147 → c = 6 → 441 - 504 = -63 → c = 5 → 441 - 420 = 21
        new BhaskaraClient(21, 21, 5),

        // Δ = 484 - 4·22·12 = 484 - 1056 = -572 → ajustado:
        // c = 8 → 484 - 704 = -220 → c = 6 → 484 - 528 = -44 → c = 5 → 484 - 440 = 44
        new BhaskaraClient(22, 22, 5),

        // Δ = 529 - 4·23·13 = 529 - 1196 = -667 → ajustado:
        // c = 7 → 529 - 644 = -115 → c = 5 → 529 - 460 = 69
        new BhaskaraClient(23, 23, 5)
    };

    return bhaskarasClient;
}