using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions {

	public class SetEventLocation : ActionTask
	{
		public BBParameter<EventLocation> currentLocation;
		protected override string OnInit()
		{
			return null;
		}

		// protected override async void OnExecute()
		// {
		// 	var selected = await GameManager2.Instance.SetChoices(new[] {
		// 		new ChoiceData(EventLocation.JobAgency.ToString(), 1),
		// 		new ChoiceData(EventLocation.TheCrypt.ToString(), 2),
		// 		new ChoiceData(EventLocation.Downtown.ToString(), 3),
		// 	});

		// 	currentLocation.value = (EventLocation)selected - 1;
		// 	EndAction(true);
		// }
		
		protected override async void OnExecute() {
			var selected = await GameManager2.Instance.SetLocationChoicesViaMap();
			currentLocation.value = (EventLocation)selected;
			EndAction(true);
		}

	}
}