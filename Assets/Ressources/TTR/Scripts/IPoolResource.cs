public interface IPoolResource
{
	string ResourceFilePath { get; set; }

	void return_to_pool(bool send_to_recycling = false);
}
