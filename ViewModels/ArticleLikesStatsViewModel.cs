using System.Collections.Generic;

namespace ViewModels
{
	public class ArticleLikesStatsViewModel
	{
		public Dictionary<int, ArticleLikesSummaryViewModel> ArticleLikesStats { get; set; }
	}
}