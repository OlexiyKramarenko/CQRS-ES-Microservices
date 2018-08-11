import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './App.css';
import { Switch, Route } from 'react-router';

// import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

import ShowCategories from './public/articles/show.categories/show.categories.component.jsx';
import BrowseArticles from './public/articles/browse.articles/browse.articles.component.jsx';
import ShowArticle from './public/articles/show.article/show.article.component.jsx';
import BrowseProducts from './public/store/browse.products/browse.products.component.jsx';
import Checkout from './public/store/checkout/checkout.component.jsx';
import OrderCompleted from './public/store/order.completed/order.completed.component.jsx';
import OrderSummary from './public/store/order.summary/order.summary.component.jsx';
import ShoppingCart from './public/store/shopping.cart/shopping.cart.component.jsx';
import ShowDepartments from './public/store/show.departments/show.departments.component.jsx';
import ShowProduct from './public/store/show.product/show.product.component.jsx';

import Default from './admin/default.jsx';

import ArticleForm from './admin/articles/article.form/article.form.jsx';
import CategoryForm from './admin/articles/category.form/category.form.jsx';
import CommentForm from './admin/articles/comment.form/comment.form.jsx';

import ManageArticles from './admin/articles/manage.articles/manage.articles.component.jsx';
import ManageCategories from './admin/articles/manage.categories/manage.categories.component.jsx';
import ManageComments from './admin/articles/manage.comments/manage.comments.component.jsx';

import DepartmentForm from './admin/store/department.form/department.form.jsx';
import OrderStatusForm from './admin/store/order.status.form/order.status.form.jsx';
import ProductForm from './admin/store/product.form/product.form.jsx';
import ShippingMethodForm from './admin/store/shipping.method.form/shipping.method.form.jsx';
// import DepartmentForm from './admin/store/edit.department/department.component.jsx';
// import EditOrderStatus from './admin/store/edit.order.status/edit.order.status.component.jsx';
// import EditProduct from './admin/store/edit.product/edit.product.component.jsx';
// import EditShippingMethod from './admin/store/edit.shipping.method/edit.shipping.method.component.jsx';
import ManageDepartments from './admin/store/manage.departments/manage.departments.component.jsx';
import ManageOrderStatuses from './admin/store/manage.order.statuses/manage.order.statuses.component.jsx';
import ManageOrders from './admin/store/manage.orders/manage.orders.component.jsx';
import ManageProducts from './admin/store/manage.products/manage.products.component.jsx';
import ManageShippingMethods from './admin/store/manage.shipping.methods/manage.shipping.methods.component.jsx';
import OrderDetails from './admin/store/order.details/order.details.jsx';

import ChangePassword from './admin/users/change.password/change.password.component.jsx';
import CreateUser from './admin/users/create.user/create.user.component.jsx';
// import EditUser from './admin/users/edit.user/edit.user.component.jsx';
import ManageUsers from './admin/users/manage.users/manage.users.component.jsx';


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
                    <a href="/">Главная</a>
                  </li>
                  <li className="">
                    <a href="/pay">Статьи</a>
                  </li>
                  <li className="">
                    <a href="/about-us">Оплата</a>
                  </li>
                  <li className="">
                    <a href="/about-us">Доставка</a>
                  </li>
                  <li className="">
                    <a href="/about-us">Контакты</a>
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

                  <img src="https://bookinstein.com.ua/image/catalog/logo.svg" title="��������-������� ���� ����������" alt="��������-������� ���� ����������"
                    className="img-responsive" data-pagespeed-url-hash="1222380375"  />
                </a>
              </div>
              <div className="auth login_home">
                <a href="https://bookinstein.com.ua/login/" rel="nofollow">вход</a> /
            <a href="https://bookinstein.com.ua/register/" rel="nofollow">регистрация</a>
              </div>
              <div className="category_block">
                <div className="category_top"></div>
                <div className="category_border">
                  <ul>
                    <li>
                      <a href="https://bookinstein.com.ua/novinki/">Шали</a>
                    </li>
                    <li className="active">
                      <a href="https://bookinstein.com.ua/coming-soon/">Вышиванки</a>
                    </li>
                    <li>
                      <a href="https://bookinstein.com.ua/biznes-literatura/">Брошки</a>
                    </li>
                  </ul>
                </div>
                <div className="category_bottom"></div>
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
                  <Route exact path="/" component={ShowCategories} />
                  <Route path="/show_categories" component={ShowCategories} />
                  <Route path="/browse_articles/:id" component={BrowseArticles} />
                  <Route path="/show_article/:id" component={ShowArticle} />
                  <Route path="/browse_products/:id" component={BrowseProducts} />
                  <Route path="/checkout" component={Checkout} />
                  <Route path="/order_completed" component={OrderCompleted} />
                  <Route path="/order_summary" component={OrderSummary} />
                  <Route path="/shopping_cart" component={ShoppingCart} />
                  <Route path="/show_departments" component={ShowDepartments} />
                  <Route path="/show_product/:id" component={ShowProduct} />

                  <Route path="/admin" component={Default} />

                  <Route path="/add_article" component={ArticleForm} />
                  <Route path="/add_category" component={CategoryForm} />
                  <Route path="/edit_article/:id" component={ArticleForm} />
                  <Route path="/edit_category/:id" component={CategoryForm} />
                  <Route path="/edit_comment/:id" component={CommentForm} />
                  
                  <Route path="/manage_articles/:id" component={ManageArticles} />
                  <Route path="/manage_categories" component={ManageCategories} />
                  <Route path="/manage_comments/:id" component={ManageComments} />

                  <Route path="/department_form" component={DepartmentForm} />
                  <Route path="/add_order_status" component={OrderStatusForm} />
                  <Route path="/add_product" component={ProductForm} />
                  <Route path="/add_shipping_method" component={ShippingMethodForm} />
                  <Route path="/edit_department/:id" component={DepartmentForm} />
                  <Route path="/edit_order_status/:id" component={OrderStatusForm} />
                  <Route path="/edit_product/:id" component={ProductForm} />
                  <Route path="/edit_shipping_method/:id" component={ShippingMethodForm} />
                  <Route path="/manage_departments" component={ManageDepartments} />
                  <Route path="/manage_order_statuses" component={ManageOrderStatuses} />
                  <Route path="/manage_orders" component={ManageOrders} />
                  <Route path="/manage_products/:id" component={ManageProducts} />
                  <Route path="/manage_shipping_methods/:id" component={ManageShippingMethods} />
                  <Route path="/order_details/:id" component={OrderDetails} />
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
