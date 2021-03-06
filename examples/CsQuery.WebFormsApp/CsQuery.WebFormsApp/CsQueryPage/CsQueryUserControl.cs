﻿using System;
using System.Collections.Generic;
using System.Web;
using CsQuery;
using CsQuery.Web;

namespace CsQuery.AspNet
{
    public class CsQueryUserControl : System.Web.UI.UserControl
    {


        public CQ Doc { get; protected set; }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            var csqContext = WebForms.CreateFromRender(this.Page, base.Render, writer);


            if (csqContext.IsAsync)
            {
                foreach (var item in csqContext.AsyncPostbackData)
                {
                    Cq_RenderUpdatePanel(item.Dom, item.ID);
                }
            }
            else
            {
                Doc = csqContext.Dom;
                Cq_Render();
            }

            Cq_Render();

            csqContext.Render();
        }

        /// <summary>
        /// Override this property to manipulate the Doc before it is rendered.
        /// </summary>

        protected virtual void Cq_Render()
        {


        }

        /// <summary>
        /// Override this property to manipulate the Doc for an update panel.
        /// </summary>
        ///
        /// <param name="doc">
        /// The CQ object representing the update panel data.
        /// </param>
        /// <param name="updatePanelId">
        /// Name ID the update panel.
        /// </param>

        protected virtual void Cq_RenderUpdatePanel(CQ doc, string updatePanelId)
        {

        }
    }
}