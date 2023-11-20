using System.Text.Json;

namespace FileReader;

public class JsonFileReader
{
	public async Task<T> ReadFromFile<T>(string fileName)
	{
		try
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);
			
			await using var fs = File.OpenRead(filePath);

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
				WriteIndented = true
			};

			var data = await JsonSerializer.DeserializeAsync<T>(fs, options);
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