using System;
using System.Collections.Generic;
using System.Data;
using dotnetCHARTING.WinForms;

namespace EV.SDDZ.BLL
{
    /// <summary>
    /// 统计图
    /// </summary>
    public class Graph
    {
        #region 属性
        private string _phaysicalimagepath;//图片存放路径
        private string _title; //图片标题
        private string _xtitle;//图片x座标名称
        private string _ytitle;//图片y座标名称
        private string _seriesname;//图例名称
        private int _picwidth;//图片宽度
        private int _pichight;//图片高度
        private DataTable _dt;//图片数据源

        /// <summary>
        /// 图片存放路径
        /// </summary>
        public string PhaysicalImagePath
        {
            set { _phaysicalimagepath = value; }
            get { return _phaysicalimagepath; }
        }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string XTitle
        {
            set { _xtitle = value; }
            get { return _xtitle; }
        }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string YTitle
        {
            set { _ytitle = value; }
            get { return _ytitle; }
        }

        /// <summary>
        /// 图例名称
        /// </summary>
        public string SeriesName
        {
            set { _seriesname = value; }
            get { return _seriesname; }
        }
        private List<string> _seriesNameList;

        public List<string> SeriesNameList
        {
            get { return _seriesNameList; }
            set { _seriesNameList = value; }
        }
        /// <summary>
        /// 图片宽度
        /// </summary>
        public int PicWidth
        {
            set { _picwidth = value; }
            get { return _picwidth; }
        }
        /// <summary>
        /// 图片高度
        /// </summary>
        public int PicHight
        {
            set { _pichight = value; }
            get { return _pichight; }
        }
        /// <summary>
        /// 图片数据源
        /// </summary>
        public DataTable DataSource
        {
            set { _dt = value; }
            get { return _dt; }
        }
        private List<DataTable> _dtList;

        public List<DataTable> DtList
        {
            get { return _dtList; }
            set { _dtList = value; }
        }
        #endregion

        public Graph()
        { 
        }
        public Graph(string PhaysicalImagePath, string Title, string XTitle, string YTitle, string SeriesName)
        {
            _phaysicalimagepath = PhaysicalImagePath;
            _title = Title;
            _xtitle = XTitle;
            _ytitle = YTitle;
            _seriesname = SeriesName;
        }

        #region 输出饼图
        /// <summary>
        /// 饼图
        /// </summary>
        /// <returns></returns>
        public void CreatePie(dotnetCHARTING.WinForms.Chart chart)
        {
            chart.Title = this._title;
            chart.TempDirectory = this._phaysicalimagepath;
            chart.Width = this._picwidth;
            chart.Height = this._pichight;
            chart.Type = ChartType.Pie;
            chart.Series.Type = SeriesType.Cylinder;
            chart.Series.Name = this._seriesname;
            chart.ShadingEffect = true;
            chart.Use3D = true;
            chart.DefaultSeries.DefaultElement.Transparency = 20;
            chart.DefaultSeries.DefaultElement.ShowValue = true;
            chart.PieLabelMode = PieLabelMode.Outside;
            chart.SeriesCollection.Add(getArrayData());
            chart.DefaultSeries.DefaultElement.ToolTip = "%Value";
            chart.Series.DefaultElement.ShowValue = true;
        }

        private SeriesCollection getArrayData()
        {
            SeriesCollection SC = new SeriesCollection();
            DataTable dt = this._dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series s = new Series();
                s.Name = dt.Rows[i][0].ToString();
                Element e = new Element();
                // 每元素的名称
                e.Name = dt.Rows[i][0].ToString();
                // 每元素的大小数值
                e.YValue = Convert.ToInt32(dt.Rows[i][1].ToString());
                s.Elements.Add(e);
                SC.Add(s);
            }
            return SC;
        }
        #endregion

        #region 输出柱形图
        /// <summary>
        /// 柱形图
        /// </summary>
        /// <returns></returns>
        public void CreateColumn(dotnetCHARTING.WinForms.Chart chart)
        {
            chart.Title = this._title;
            chart.XAxis.Label.Text = this._xtitle;
            chart.YAxis.Interval = 1;
            chart.YAxis.Label.Text = this._ytitle;
            chart.TempDirectory = this._phaysicalimagepath;
            chart.Width = this._picwidth;
            chart.Height = this._pichight;
            chart.Type = ChartType.Combo;
            chart.DefaultSeries.Type = SeriesType.Cylinder;
            chart.Series.Name = this._seriesname;
            chart.Series.Data = this._dt;
            chart.SeriesCollection.Add();
            chart.DefaultSeries.DefaultElement.ToolTip = "%Value";
            chart.DefaultSeries.DefaultElement.ShowValue = true;
            chart.ShadingEffect = true;
            chart.Use3D = true;
            chart.Series.DefaultElement.ShowValue = true;
        }
        #endregion

        #region 输出曲线图
        /// <summary>
        /// 曲线图
        /// </summary>
        /// <returns></returns>
        public void CreateLine(dotnetCHARTING.WinForms.Chart chart)
        {
            chart.Title = this._title;
            chart.XAxis.Label.Text = this._xtitle;
            chart.YAxis.Label.Text = this._ytitle;
            //chart.YAxis.Markers.Add(new AxisMarker("", Color.FromArgb(50, Color.Red), 40, 100));
            //chart.YAxis.Markers.Add(new AxisMarker("", Color.FromArgb(50, Color.Red), 0, 20));
            chart.TempDirectory = this._phaysicalimagepath;
            chart.Width = this._picwidth;
            chart.Height = this._pichight;
            chart.Type = ChartType.Combo; 
            chart.DefaultSeries.Type = SeriesType.Line;
            //chart.Series.Type =SeriesType.Line;
            chart.Series.Name = this._seriesname;
            if (chart.SeriesCollection.Count > 0)
            {
                chart.SeriesCollection.Clear();
            }
            for (int i = 0; i < this._dtList.Count; i++)
            {
                chart.Series.Data = this._dtList[i];
                chart.Series.Name = this._seriesNameList[i];
                chart.SeriesCollection.Add(); 
            }
            chart.DefaultSeries.DefaultElement.ShowValue = false;
            // chart.LegendBox.Background.Color = Color.FromArgb(100, chart.LegendBox.Background.Color);            
            // chart.LegendBox.Shadow.Color = Color.Empty;
            //chart.LegendBox.Position = new Point(40, 40);
            chart.LegendBox.HeaderLabel.Text = "图例";
            chart.LegendBox.Position = LegendBoxPosition.Top;//提示说明框的位置
            chart.DefaultSeries.DefaultElement.ToolTip = "%Value";
            chart.XAxis.Scale = Scale.FullStacked;
            chart.Use3D = false;
            chart.Series.DefaultElement.ShowValue = false;
        }
        #endregion
    }
}
