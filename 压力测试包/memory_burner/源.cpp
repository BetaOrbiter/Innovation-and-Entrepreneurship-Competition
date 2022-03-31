#include <thread>
#include <chrono>

static char* mem = nullptr;
void burn(const uint64_t size,const int seed) {
	int* const line = (int*)mem;
	while (true)
		for (uint64_t i = 8; i + 8 < size; i += 8) {
			line[i - 0] = line[i + 8] + seed;
			line[i - 1] = line[i + 7] + seed;
			line[i - 2] = line[i + 6] + seed;
			line[i - 3] = line[i + 5] + seed;
			line[i - 4] = line[i + 4] + seed;
			line[i - 5] = line[i + 3] + seed;
			line[i - 6] = line[i + 2] + seed;
			line[i - 7] = line[i + 1] + seed;
		}
}

int main(int argc, char* argv[]) {
	if (argc != 4) {
		fprintf(stderr,"Usage: memory_burner.exe phycial_memory_size burn_time thread_number\n");
		exit(1);
	}
	const uint64_t size	   = strtoull(argv[1], NULL, 10);
	const uint64_t time    = strtoull(argv[2], NULL, 10);
	const uint64_t nthread = strtoull(argv[3], NULL, 10);

	if ((mem = (char*)malloc(size)) == nullptr) {
		fprintf(stderr, "Memory allocation failed!\n");
		exit(2);
	}
	for (int i = 0; i < nthread; ++i)
		std::thread(burn, size / sizeof(int), rand()).detach();
	std::this_thread::sleep_for(std::chrono::seconds(time));
	exit(0);
}