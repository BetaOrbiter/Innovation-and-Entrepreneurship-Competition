#include <thread>
#include <chrono>

void cpu_burn() {
    constexpr size_t len = 64;
    double x[len];
    double y[len];
    double z[len];
    while (true) {
        for (int i = 0; i < len; ++i)
            z[i] += x[i] * y[i];
    }
}

int main(int argc, char* argv[]) {
    if (argc != 3) {
        fprintf(stderr, "Usage: cpu_burner.exe burn_time thread_number\n");
        exit(1);
    }
    const uint64_t duration = strtoull(argv[1], NULL, 10);
    const uint64_t threads  = strtoull(argv[2], NULL, 10);

    for (int i = 0; i < threads; ++i)
        std::thread(cpu_burn).detach();
    std::this_thread::sleep_for(std::chrono::seconds(duration));
    exit(0);
}