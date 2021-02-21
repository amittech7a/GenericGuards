namespace SmartSolutions.Guards
{
   /// <summary>
   /// Guard class for 
   /// </summary>
    public class Guard : IGuardClause
    {
        private Guard()
        {

        }
        /// <summary>
        ///     An entry point to a set of Guard Clauses.
        /// </summary>
        public static IGuardClause Against { get; } = new Guard();
    }
}
