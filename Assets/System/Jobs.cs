public class Jobs {

    // The list of possible careers
    public enum Career { None, Cashier, Waiter, SoftwareDev, CEO };

    /** Returns the money increase value of each job -- can reiterate if jobs return incremental salary rather than
     *  lump sum
     */
    public static int getMoney(Career jobs) {
        switch(jobs) {
            case Career.Cashier:
                return 500;
            case Career.Waiter:
                return 1000;
            case Career.SoftwareDev:
                return 5000;
            case Career.CEO:
                return 10000;
            default:
                return 0;
        }
    }
}