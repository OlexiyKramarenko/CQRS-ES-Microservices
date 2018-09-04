import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './App.css';
import './index.css';
import {  Switch, Route } from 'react-router-dom';
 
import CategoriesPage from './components/categories.page'; //'./public/articles/show.categories/show.categories.component.jsx';
import ArticlesPage from './components/articles.page';
import ArticleInfo from './components/article.info';
import ManageCategories from './components/manage.categories';
import ManageArticles from './components/manage.articles';
import CategoryForm from './components/category.form';
import ArticleForm from './components/article.form';

class App extends Component {

  render() {

    return (
      <div>
        <header className="header__allpage">
          <div className="container">
            <div className="header_right">
              <div className="phones">
                <div className="phone1">
                  +38 (097) 456-75-83
            </div>
                <div className="phone2">
                  +38 (095) 450-50-74
            </div>
              </div>
              <div id="search">
                <input type="text" name="search" value="" placeholder="Поиск..." className="form-control input-lg ui-autocomplete-input" autoComplete="off" />
                <button type="button" className="button_search">
                  <i className="fa fa-search"></i>
                </button>
              </div>
              <div id="cart">
                <div className="cart_wrap">
                  <a href="https://bookinstein.com.ua/index.php?route=checkout/cart" rel="nofollow">
                    <span className="text_cart">Корзина: </span>
                    <span id="cart-total">0 шт.
                  <br /> на 0 грн</span>
                  </a>
                </div>
              </div>
              <nav className="main_menu">
                <ul className="nav_ul">
                  <li className="">
                    <Link to="/categories">User section</Link>
                  </li>
                  <li className="">
                    <Link to="/manage_categories">Administrator section</Link>
                  </li>
                </ul>
              </nav>
            </div>
          </div>
        </header>


        <div className="container">
          <div className="row">
            <aside className="column_left">
              <div className="logo">
                <a href="https://bookinstein.com.ua/">

                  <img src="https://bookinstein.com.ua/image/catalog/logo.svg" 
                    className="img-responsive" data-pagespeed-url-hash="1222380375"  />
                </a>
              </div>
              <div className="auth login_home">
                <a href="https://bookinstein.com.ua/login/" rel="nofollow">вход</a> /
            <a href="https://bookinstein.com.ua/register/" rel="nofollow">регистрация</a>
              </div>             
            </aside>
            <div id="content">
              <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u"
                crossOrigin="anonymous" />
              <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"
                crossOrigin="anonymous"></script>

              <div className="box_module featured box_module_0">
                <div className="heading_title">
                  <div className="heading_bg">Контакты</div>
                </div>

                <Switch>
                  <Route exact path="/" component = {CategoriesPage} />
                  <Route exact path="/categories" component = {CategoriesPage} /> 
                  <Route path="/categories/:id" component = {ArticlesPage} />                   
                  <Route path="/articles/:id" component = {ArticleInfo} /> 
                  <Route exact path="/manage_categories" component = {ManageCategories} />
                  <Route path="/manage_categories/:id" component = {ManageArticles} />                  
                  <Route path="/category_form/:id" component = {CategoryForm} />
                  <Route path="/category_form" component = {CategoryForm} />
                  <Route path="/article_form/:id" component = {ArticleForm} />
                  <Route path="/article_form" component = {ArticleForm} />
                </Switch>

              </div>
            </div>
          </div>
        </div>

      <footer>
          <div className="container">
            <div className="footer_wrap">
              <nav className="footer_menu">
                <ul className="footer_ul"></ul>
              </nav>
              <div className="footer_bottom row">
                <div className="footer_social col-sm-12">
                  <ul>
                    <li>
                      <a className="fb_icon" href="https://www.facebook.com/bookinstein" target="_blank" data-toggle="tooltip" title=""  
                        data-original-title="Facebook Bookinstein"></a>
                    </li>
                    <li>
                      <a className="vk_icon" href="http://vk.com/bookinstein" target="_blank" data-toggle="tooltip" title="" 
                        data-original-title="��������� Bookinstein"></a>
                    </li>
                    <li>
                      <a className="tw_icon" href="https://twitter.com/Bookinstein" target="_blank" data-toggle="tooltip" title="" 
                        data-original-title="Twitter Bookinstein"></a>
                    </li>
                    <li>
                      <a className="gp_icon" href="https://plus.google.com/+������������������������������������/" target="_blank" data-toggle="tooltip"
                        title="" data-original-title="Google+ Bookinstein"></a>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </footer>  

        <div className="scroll_wrapper">
          <div className="container">
            <div className="scrollup" style={{ display: "none" }}>
              <i className="fa fa-arrow-up"></i>
            </div>
          </div>
        </div>

        <script type="text/javascript">var google_conversion_id = 864913304; var google_custom_params = window.google_tag_params; var google_remarketing_only = true;</script>
        <script type="text/javascript" src="//www.googleadservices.com/pagead/conversion.js"></script>

        <ul className="ui-autocomplete ui-front ui-menu ui-widget ui-widget-content" id="ui-id-1" tabIndex="0" style={{ display: "none" }}></ul>
        <span role="status" aria-live="assertive" aria-relevant="additions" className="ui-helper-hidden-accessible"></span>
      </div>
    );
  }
}

export default App;
