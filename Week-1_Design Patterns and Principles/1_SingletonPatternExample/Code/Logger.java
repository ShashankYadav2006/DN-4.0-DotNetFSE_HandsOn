public class Logger {
    private static volatile Logger instance;

    private Logger() {
        System.out.println("[Logger Initialized]");
    }

    public static Logger getInstance() {
        if (instance == null) {
            synchronized (Logger.class) {
                if (instance == null) {
                    instance = new Logger();
                }
            }
        }
        return instance;
    }

    public void log(String message) {
        String threadName = Thread.currentThread().getName();
        System.out.println("[" + threadName + "] Logging message: \"" + message + "\"");
    }
}
