namespace RhythsTileEditor.Mono.Components
{
    /// <summary>
    /// Marks the class to handle a primary and secondary click.
    /// </summary>
    public interface IClickable
    {
        /// <summary>
        /// A primary click occured.
        /// </summary>
        void Click();

        /// <summary>
        /// a secondary click occured.
        /// </summary>
        void SecondaryClick();
    }
}
