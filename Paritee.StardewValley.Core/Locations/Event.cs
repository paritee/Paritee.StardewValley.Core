using StardewValley;
using StardewValley.Events;

namespace Paritee.StardewValley.Core.Locations
{
    public class Event
    {
        // Farmer events
        public const int BlueChicken = 3900074;

        // Farm events
        public const int SoundInTheNightAnimalEaten = 2;

        public static global::StardewValley.Event GetEventInLocation(GameLocation location)
        {
            return location.currentEvent;
        }

        public static bool IsEventOccurringInLocation(GameLocation location)
        {
            return Locations.Event.GetEventInLocation(location) != null;
        }

        public static void GoToNextEventCommandInLocation(GameLocation location)
        {
            if (Locations.Event.IsEventOccurringInLocation(location))
            {
                ++Locations.Event.GetEventInLocation(location).CurrentCommand;
            }
        }

        public static bool TryGetFarmEvent<T>(out T farmEvent)
        {
            farmEvent = default(T);

            if (Game1.farmEvent == null)
            {
                return false;
            }

            if (!(Game1.farmEvent is T))
            {
                return false;
            }

            farmEvent = (T)Game1.farmEvent;

            return true;
        }

        public static bool IsFarmEventOccurring<T>(out T farmEvent)
        {
            return Locations.Event.TryGetFarmEvent<T>(out farmEvent);
        }

        public static void ForceQuestionEventToProceed(QuestionEvent questionEvent)
        {
            questionEvent.forceProceed = true;
        }
    }
}
