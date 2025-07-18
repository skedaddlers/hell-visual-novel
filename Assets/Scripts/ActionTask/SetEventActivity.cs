using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class SetEventActivity : ActionTask {
		public BBParameter<EventActivity> currentActivity;
		
		protected override async void OnExecute() {
			var selected = await GameManager2.Instance.SetChoices(new [] {
				new ChoiceData(EventActivity.GainCurrency.ToString(), 1),
				new ChoiceData(EventActivity.GainRelationship.ToString(), 2),
			});
			
			currentActivity.value = (EventActivity)selected - 1;
			EndAction(true);
		}
	}
}