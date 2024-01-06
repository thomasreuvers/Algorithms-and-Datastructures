using System.Text.Json;

namespace FileReader;

public class JsonFileReader
{
	private readonly JsonSerializerOptions _options = new()
	{
		PropertyNameCaseInsensitive = true,
		WriteIndented = true
	};
	
	public async Task<T> ReadFromFile<T>(string fileName)
	{
		try
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);
			
			await using var fs = File.OpenRead(filePath);

			var data = await JsonSerializer.DeserializeAsync<T>(fs, _options);
			return data ?? throw new InvalidOperationException("empty dataset");
		}
		catch (FileNotFoundException ex)
		{
			throw new FileNotFoundException("File not found", ex.FileName);
		}
		catch (Exception ex)
		{
			throw new Exception("Error reading JSON file", ex);
		}
	}
}