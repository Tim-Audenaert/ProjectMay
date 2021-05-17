using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectMay
{
    /// <summary>
    /// Interaction logic for UserOverview.xaml
    /// </summary>
    public partial class UserOverview : Page
    {
		private GridViewColumnHeader listViewSortCol = null;
		private SortAdorner listViewSortAdorner = null;

		public UserOverview()
        {
            InitializeComponent();
			using (Context ctx = new Context())
			{
				var users = ctx.Users.Include(u => u.Role);
				foreach (var item in users)
				{
					LvwUsers.Items.Add(item);
				}
			}
		}

		private void Sort(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader column = sender as GridViewColumnHeader;
			ListView listview = sender as ListView;
			string sortBy = column.Tag.ToString();
			if (listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
				listview.Items.SortDescriptions.Clear();
			}

			ListSortDirection newDir = ListSortDirection.Ascending;
			if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
				newDir = ListSortDirection.Descending;

			listViewSortCol = column;
			listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
			AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
			listview.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
		}

		public class SortAdorner : Adorner
		{
			private static Geometry ascGeometry =
				Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

			private static Geometry descGeometry =
				Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

			public ListSortDirection Direction { get; private set; }

			public SortAdorner(UIElement element, ListSortDirection dir)
				: base(element)
			{
				this.Direction = dir;
			}

			protected override void OnRender(DrawingContext drawingContext)
			{
				base.OnRender(drawingContext);

				if (AdornedElement.RenderSize.Width < 20)
					return;

				TranslateTransform transform = new TranslateTransform
					(
						AdornedElement.RenderSize.Width - 15,
						(AdornedElement.RenderSize.Height - 5) / 2
					);
				drawingContext.PushTransform(transform);

				Geometry geometry = ascGeometry;
				if (this.Direction == ListSortDirection.Descending)
					geometry = descGeometry;
				drawingContext.DrawGeometry(Brushes.Black, null, geometry);

				drawingContext.Pop();
			}
		}
	}
}
