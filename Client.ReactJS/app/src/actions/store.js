import { handleResponse, SERVICE_BASE } from './base';

export const PRODUCT_FETCHED = "PRODUCT_FETCHED";
export function productFetched(product) {
    return {
        type: PRODUCT_FETCHED,
        payload: product
    }
}
export function showProduct(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ShowProduct/${id}`)
            .then(res => res.json())
            .then(data => dispatch(productFetched(data.product)));
    }
}

export function editProduct(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/EditProduct/${id}`)
            .then(res => res.json())
            .then(data => dispatch(productFetched(data.product)));
    }
}


export const PRODUCT_DELETED = "PRODUCT_DELETED";
export function productDeleted(productId) {
    return {
        type: PRODUCT_DELETED,
        payload: productId
    }
}
export function deleteProduct(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/DeleteProduct/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(productDeleted(id)));
    }
}


export const PRODUCTS_FETCHED = "PRODUCTS_FETCHED";
export function productsFetched(products) {
    return {
        type: PRODUCTS_FETCHED,
        payload: products
    }
}
export function browseProducts(departmentId) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/BrowseProducts/${departmentId}`)
            .then(res => res.json())
            .then(data => dispatch(productsFetched(data.products)));
    }
}

export function manageProducts(pageIndex, pageSize) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ManageProducts/${pageIndex}/${pageSize}`)
            .then(res => res.json())
            .then(data => dispatch(productsFetched(data.products)));
    }
}


export const DEPARTMENTS_FETCHED = "DEPARTMENTS_FETCHED";
export function departmentsFetched(departments) {
    return {
        type: DEPARTMENTS_FETCHED,
        payload: departments
    }
}
export function showDepartments() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ShowDepartments`)
            .then(res => res.json())
            .then(data => dispatch(departmentsFetched(data.departments)));
    }
}

export function manageDepartments() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ManageDepartments`)
            .then(res => res.json())
            .then(data => dispatch(departmentsFetched(data.departments)));
    }
}

export const SHIPPING_DETAILS_FETCHED = "SHIPPING_DETAILS_FETCHED";
export function shippingDetailsFetched(shippingDetails) {
    return {
        type: SHIPPING_DETAILS_FETCHED,
        payload: shippingDetails
    }
}
export function shippingDetails(shippingMethodId) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ShippingDetails/${shippingMethodId}`)
            .then(res => res.json())
            .then(data => dispatch(shippingDetailsFetched(data.shippingDetails)));
    }
}


export const SHIPPING_METHODS_FETCHED = "SHIPPING_METHODS_FETCHED";
export function shippingMethodsFetched(shippingMethods) {
    return {
        type: SHIPPING_METHODS_FETCHED,
        payload: shippingMethods
    }
}
export function shippingMethods() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ShippingMethods`)
            .then(res => res.json())
            .then(data => dispatch(shippingMethodsFetched(data.shippingMethods)));
    }
}
export function manageShippingMethods() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ManageShippingMethods`)
            .then(res => res.json())
            .then(data => dispatch(shippingMethodsFetched(data.shippingMethods)));
    }
}


export const CHECKOUT_FETCHED = "CHECKOUT_FETCHED";
export function checkoutFetched(checkout) {
    return {
        type: CHECKOUT_FETCHED,
        payload: checkout
    }
}
export function checkout() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/Checkout`)
            .then(res => res.json())
            .then(data => dispatch(checkoutFetched(data.checkout)));
    }
}



export const CHECKOUT_ADDED = "CHECKOUT_ADDED";
export function checkoutAdded(checkout) {
    return {
        type: CHECKOUT_ADDED,
        payload: checkout
    }
}
export function postCheckout(checkout) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/Checkout`, {
            method: 'post',
            body: JSON.stringify(checkout),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(checkoutAdded(data.checkout)));
    }
}


export const SHOPPING_CART_FETCHED = "SHOPPING_CART_FETCHED";
export function shoppingCartFetched(shoppingCart) {
    return {
        type: SHOPPING_CART_FETCHED,
        payload: shoppingCart
    }
}
export function shoppingCart() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ShoppingCart`)
            .then(res => res.json())
            .then(data => dispatch(shoppingCartFetched(data.shoppingCart)));
    }
}




export const SHOPPING_CART_ADDED = "SHOPPING_CART_ADDED";
export function shoppingCartAdded(shoppingCart) {
    return {
        type: SHOPPING_CART_ADDED,
        payload: shoppingCart
    }
}
export function postShoppingCart(cart) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ShoppingCart`, {
            method: 'post',
            body: JSON.stringify(cart),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(shoppingCartAdded(data.shoppingCart)));
    }
}



export const SHOPPING_CART_ITEM_ADDED = "SHOPPING_CART_ITEM_ADDED";
export function shoppingCartItemAdded(cartItem) {
    return {
        type: SHOPPING_CART_ITEM_ADDED,
        payload: cartItem
    }
}
export function addToShoppingCart(cartItem) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/AddToShoppingCart`, {
            method: 'post',
            body: JSON.stringify(cartItem),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(shoppingCartItemAdded(data.cartItem)));
    }
}





export const DELETED_FROM_SHOPPING_CART = "DELETED_FROM_SHOPPING_CART";
export function deletedFromShoppingCart(id) {
    return {
        type: DELETED_FROM_SHOPPING_CART,
        payload: id
    }
}
export function removeFromShoppingCart(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/RemoveFromShoppingCart/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(deletedFromShoppingCart(data.id)));
    }
}


export const ORDER_ADDED = "ORDER_ADDED";
export function orderAdded(cartItem) {
    return {
        type: ORDER_ADDED,
        payload: cartItem
    }
}
export function orderSummary(order) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/OrderSummary`, {
            method: 'post',
            body: JSON.stringify(order),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(orderAdded(data.order)));
    }
}


export const ORDER_HISTORY = "ORDER_HISTORY";
export function orderHistoryFetched(orderHistory) {
    return {
        type: ORDER_HISTORY,
        payload: orderHistory
    }
}
export function orderHistory(statusId, fromDate, toDate) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/OrderHistory/${statusId}/${fromDate}/${toDate}`)
            .then(res => res.json())
            .then(data => dispatch(orderHistoryFetched(data.orderHistory)));
    }
}





export const PRODUCT_ADDED = "ORDER_ADDED";
export function productAdded(product) {
    return {
        type: PRODUCT_ADDED,
        payload: product
    }
}
export function addProduct(product) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/AddProduct`, {
            method: 'post',
            body: JSON.stringify(product),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(productAdded(data.product)));
    }
}






export const PRODUCT_UPDATED = "PRODUCT_UPDATED";
export function productUpdated(product) {
    return {
        type: PRODUCT_UPDATED,
        payload: product
    }
}
export function updateProduct(product) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/UpdateProduct/${product._id}`, {
            method: 'put',
            body: JSON.stringify(product),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(productUpdated(data.product)));
    }
}




export const SHIPPING_METHOD_DELETED = "SHIPPING_METHOD_DELETED";
export function shippingMethodDeleted(id) {
    return {
        type: SHIPPING_METHOD_DELETED,
        payload: id
    }
}
export function deleteShippingMethod(id) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/DeleteShippingMethod/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(shippingMethodDeleted(id)));
    }
}




export const SHIPPING_METHOD_ADDED = "SHIPPING_METHOD_ADDED";
export function shippingMethodAdded(shippingMethod) {
    return {
        type: SHIPPING_METHOD_ADDED,
        payload: shippingMethod
    }
}
export function addShippingMethod(method) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/AddShippingMethod`, {
            method: 'post',
            body: JSON.stringify(method),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(productAdded(data.method)));
    }
}


export const SHIPPING_METHOD_FETCHED = "SHIPPING_METHOD_FETCHED";
export function shippingMethodFetched(method) {
    return {
        type: SHIPPING_METHOD_FETCHED,
        payload: method
    }
}
export function editShippingMethod(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/EditShippingMethod/${id}`)
            .then(res => res.json())
            .then(data => dispatch(shippingMethodFetched(data.method)));
    }
}


export const SHIPPING_METHOD_UPDATED = "SHIPPING_METHOD_UPDATED";
export function shippingMethodUpdated(method) {
    return {
        type: SHIPPING_METHOD_UPDATED,
        payload: method
    }
}
export function updateShippingMethod(method) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/UpdateShippingMethod/${method._id}`, {
            method: 'put',
            body: JSON.stringify(method),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(shippingMethodUpdated(data.method)));
    }
}





export const DEPARTMENT_DELETED = "DEPARTMENT_DELETED";
export function departmentDeleted(id) {
    return {
        type: DEPARTMENT_DELETED,
        payload: id
    }
}
export function deleteDepartment(id) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/DeleteDepartment/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(departmentDeleted(id)));
    }
}


export const DEPARTMENT_ADDED = "DEPARTMENT_ADDED";
export function departmentAdded(department) {
    return {
        type: DEPARTMENT_ADDED,
        payload: department
    }
}
export function addDepartment(department) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/AddDepartment`, {
            method: 'post',
            body: JSON.stringify(department),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(departmentAdded(data.department)));
    }
}




export const DEPARTMENT_FETCHED = "DEPARTMENT_FETCHED";
export function departmentFetched(department) {
    return {
        type: DEPARTMENT_FETCHED,
        payload: department
    }
}
export function editDepartment(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/EditDepartment/${id}`)
            .then(res => res.json())
            .then(data => dispatch(departmentFetched(data.department)));
    }
}
 
export const DEPARTMENT_UPDATED = "DEPARTMENT_UPDATED";
export function departmentUpdated(department) {
    return {
        type: DEPARTMENT_UPDATED,
        payload: department
    }
}
export function updateDepartment(department) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/UpdateDepartment/${department._id}`, {
            method: 'put',
            body: JSON.stringify(department),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(departmentUpdated(data.department)));
    }
}



export const ORDERS_FETCHED = "ORDERS_FETCHED";
export function ordersFetched(orders) {
    return {
        type: ORDERS_FETCHED,
        payload: orders
    }
}
export function manageOrders() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ManageOrders`)
            .then(res => res.json())
            .then(data => dispatch(ordersFetched(data.orders)));
    }
}

// export function manageOrders(pageIndex, pageSize) {
//     return dispatch => {
//         fetch(SERVICE_BASE + `/api/store/ManageOrders/${pageIndex}/${pageSize}`)
//             .then(res => res.json())
//             .then(data => dispatch(ordersFetched(data.orders)));
//     }
// }



export const ORDER_DELETED = "ORDER_DELETED";
export function orderDeleted(id) {
    return {
        type: ORDER_DELETED,
        payload: id
    }
}
export function deleteOrder(id) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/DeleteOrder/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(orderDeleted(data.id)));
    }
}



export const ORDER_DETAILS_FETCHED = "ORDER_DETAILS_FETCHED";
export function orderDetailsFetched(orderDetails) {
    return {
        type: ORDER_DETAILS_FETCHED,
        payload: orderDetails
    }
}
export function orderDetails(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/OrderDetails/${id}`)
            .then(res => res.json())
            .then(data => dispatch(orderDetailsFetched(data.id)));
    }
}

 



 
export const ORDER_STATUSES_FETCHED = "ORDER_STATUSES_FETCHED";
export function orderStatusesFetched(orderStatuses) {
    return {
        type: ORDER_STATUSES_FETCHED,
        payload: orderStatuses
    }
}
export function manageOrderStatuses() {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/ManageOrderStatuses`)
            .then(res => res.json())
            .then(data => dispatch(orderStatusesFetched(data.orderStatuses)));
    }
}




export const ORDER_STATUS_DELETED = "ORDER_STATUS_DELETED";
export function orderStatusDeleted(id) {
    return {
        type: ORDER_STATUS_DELETED,
        payload: id
    }
}
export function deleteOrderStatus(id) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/DeleteOrderStatus/${id}`, {
            method: 'delete',
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(orderStatusDeleted(data.id)));
    }
}



export const ORDER_STATUS_FETCHED = "ORDER_STATUS_FETCHED";
export function orderStatusFetched(orderStatus) {
    return {
        type: ORDER_STATUS_FETCHED,
        payload: orderStatus
    }
}
export function editOrderStatus(id) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/EditOrderStatus/${id}`)
            .then(res => res.json())
            .then(data => dispatch(orderStatusFetched(data.orderStatus)));
    }
}

export const ORDER_STATUS_UPDATED = "ORDER_STATUS_UPDATED";
export function orderStatusUpdated(orderStatus) {
    return {
        type: ORDER_STATUS_UPDATED,
        payload: orderStatus
    }
}
export function updateOrderStatus(orderStatus) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/UpdateOrderStatus/${orderStatus._id}`, {
            method: 'put',
            body: JSON.stringify(orderStatus),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(orderStatusUpdated(data.orderStatus)));
    }
}


export const ORDER_STATUS_ADDED = "ORDER_STATUS_ADDED";
export function orderStatusAdded(orderStatus) {
    return {
        type: ORDER_STATUS_ADDED,
        payload: orderStatus
    }
}
export function addOrderStatus(orderStatus) {

    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/AddOrderStatus`, {
            method: 'post',
            body: JSON.stringify(orderStatus),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(handleResponse)
            .then(data => dispatch(orderStatusAdded(data.orderStatus)));
    }
}






 
export const ORDER_STATUSID_UPDATED = "ORDER_STATUSID_UPDATED";
export function orderStatusIdUpdated(orderStatusId) {
    return {
        type: ORDER_STATUSID_UPDATED,
        payload: orderStatusId
    }
}
export function updateOrderStatusId(data) {
    return dispatch => {
        fetch(SERVICE_BASE + `/api/store/UpdateOrderStatusId/${data._id}/${data.statusId}`)
            .then(res => res.json())
            .then(data => dispatch(orderStatusIdUpdated(data.id)));
    }
}