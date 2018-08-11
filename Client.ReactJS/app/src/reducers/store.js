import {
    PRODUCT_FETCHED, PRODUCT_DELETED, 
    SHIPPING_DETAILS_FETCHED,
    SHIPPING_METHODS_FETCHED, CHECKOUT_FETCHED,
    CHECKOUT_ADDED, SHOPPING_CART_FETCHED,
    SHOPPING_CART_ADDED, SHOPPING_CART_ITEM_ADDED,
    DELETED_FROM_SHOPPING_CART, ORDER_ADDED,
    ORDER_HISTORY, PRODUCTS_FETCHED, PRODUCT_ADDED,
    PRODUCT_UPDATED, SHIPPING_METHOD_DELETED,
    SHIPPING_METHOD_ADDED, SHIPPING_METHOD_FETCHED,
    SHIPPING_METHOD_UPDATED, DEPARTMENTS_FETCHED,
    DEPARTMENT_DELETED, DEPARTMENT_ADDED,
    DEPARTMENT_FETCHED, DEPARTMENT_UPDATED,
    ORDERS_FETCHED, ORDER_DELETED,
    ORDER_DETAILS_FETCHED,
    ORDER_STATUSES_FETCHED, ORDER_STATUS_DELETED,
    ORDER_STATUS_UPDATED, ORDER_STATUS_ADDED
}
    from "../actions/store";

export default function games(state = [], action = {}) {

    switch (action.type) {
        case PRODUCT_UPDATED:
        case SHIPPING_METHOD_UPDATED:
        case DEPARTMENT_UPDATED:
        case ORDER_STATUS_UPDATED:
            return state.map(item => {
                if(item._id === action.payload.id)
                    return item;
            });

        case PRODUCT_FETCHED:
        case SHIPPING_DETAILS_FETCHED:
        case SHIPPING_METHODS_FETCHED:
        case CHECKOUT_FETCHED:
        case SHOPPING_CART_FETCHED:
        case PRODUCTS_FETCHED:
        case SHIPPING_METHOD_FETCHED:
        case DEPARTMENTS_FETCHED:
        case DEPARTMENT_FETCHED:
        case ORDERS_FETCHED:
        case ORDER_DETAILS_FETCHED:
        case ORDER_STATUSES_FETCHED:
            const index = state.findIndex(item => item._id == action.payload._id);
            if(index >-1){
                return state.map(item => {
                    if(item._id === action.payload._id)
                    return item;
                });
            }
            else{
                return [
                    ...state,
                    action.payload
                ];
            }  

        case PRODUCT_DELETED:
        case DELETED_FROM_SHOPPING_CART:
        case SHIPPING_METHOD_DELETED:
        case DEPARTMENT_DELETED:
        case ORDER_DELETED:
        case ORDER_STATUS_DELETED:
            return state.filter(item => item._id !== action.payload)
 
        case CHECKOUT_ADDED:
        case SHOPPING_CART_ADDED:
        case SHOPPING_CART_ITEM_ADDED:
        case ORDER_ADDED:
        case PRODUCT_ADDED:
        case SHIPPING_METHOD_ADDED:
        case DEPARTMENT_ADDED:
        case ORDER_STATUS_ADDED:
            return [...state, action.payload];
             
        default:
            return state;
    }
}