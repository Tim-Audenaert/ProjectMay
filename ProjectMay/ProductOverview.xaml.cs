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
    /// Interaction logic for ProductOverview.xaml
    /// </summary>
    public partial class ProductOverview : Page
    {
		private GridViewColumnHeader listViewSortCol = null;
		private SortAdorner listViewSortAdorner = null;
		private List<Product> products;
		private List<Product> filteredProducts;
		public ProductOverview()
        {
            InitializeComponent();
			products = new List<Product>();
			using (Context ctx = new Context())
			{
				products = ctx.Products.ToList();
				foreach (var item in products)
				{
					LvwProducts.Items.Add(item);
				}
			}

			var filteredProducts = new List<Product>();

		}	

		private void ShowHideWatermark(object sender, RoutedEventArgs e)
		{
			SearchWatermark.Visibility = (TxtSearch.Text == "" && TxtSearch.IsFocused == false) ? Visibility.Visible : Visibility.Collapsed;
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
		private void Sort(object sender, RoutedEventArgs e)
		{
			ListView listview = sender as ListView;
			GridViewColumnHeader column = e.OriginalSource as GridViewColumnHeader;
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

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
			//LvwProducts.Items.Clear();
			//var toAdd = products.Where(p => p.Name.ToLower().Contains(TxtSearch.Text.ToLower()));
			//if (toAdd != null || TxtSearch.Text != "")
			//{
			//	filteredProducts.Clear();
			//	foreach (var item in toAdd)
			//	{
			//		filteredProducts.Add(item);
			//	}
			//}
			//if (filteredProducts != null)
			//{
			//	foreach (var item in filteredProducts)
			//	{
			//		LvwProducts.Items.Add(item);
			//	}
			//}
        }
    }
}
 