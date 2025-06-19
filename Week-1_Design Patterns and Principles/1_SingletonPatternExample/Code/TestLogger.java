public class TestLogger {
    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();
        logger1.log("First message");
        logger2.log("Second message");
        System.out.println("Logger instance comparison: logger1 and logger2 refer to the same object ? " + (logger1 == logger2));
        Thread t1 = new Thread(() -> {
            Logger l = Logger.getInstance();
            l.log("Message from thread 1");
        }, "Thread-1");
        Thread t2 = new Thread(() -> {
            Logger l = Logger.getInstance();
            l.log("Message from thread 2");
        }, "Thread-2");
        t1.start();
        t2.start();
    }
}
