using Android.Content;

namespace Xamarin.Forms.Platform.Android
{
	public class CarouselViewRenderer : ItemsViewRenderer
	{

		// TODO hartez 2018/08/29 17:13:17 Does this need to override SelectLayout so it ignores grids?	

		public CarouselViewRenderer(Context context) : base(context)
		{
		}

		protected override void UpdateItemsSource()
		{
			if (ItemsView == null)
			{
				return;
			}

			// By default the CollectionViewAdapter creates the items at whatever size the template calls for
			// But for the Carousel, we want it to create the items to fit the width/height of the viewport
			// So we give it an alternate delegate for creating the views

			var adapter = new CollectionViewAdapter(ItemsView, Context, 
				(renderer, context) => new SizedItemContentControl(renderer, context, () => Width, () => Height));

			SetAdapter(adapter);
		}
	}
}