import { handleResponse } from './actionBase';
import { SERVICE_BASE } from '../constants/config';

export const SET_CATEGORIES = "SET_CATEGORIES";
export const SET_CATEGORY = "SET_CATEGORY";
export const CATEGORY_DELETED = "CATEGORY_DELETED";
export const CATEGORY_UPDATED = "CATEGORY_UPDATED";
export const CATEGORY_ADDED = "CATEGORY_ADDED";

export function setCategory(category) {   
    
    return {
        type: SET_CATEGORY,
        payload: category
    }
}

export function setCategories(categories) {   
    
    return {
        type: SET_CATEGORIES,
        payload: categories
    }
}
 
export function categoryDeleted(categoryId){

    return {
        type : CATEGORY_DELETED,
        payload: categoryId
    }    
}

export function categorySaved(category){

    return {
        type : CATEGORY_ADDED,
        payload: category
    }
}

export function categoryUpdated(category){

    return {
        type : CATEGORY_UPDATED,
        payload: category
    }
}

export function fetchCategories() {
    
    return dispatch => {
        fetch(`${SERVICE_BASE}/api/v1/categories`)
            .then(res => res.json())  
            .then(data => dispatch(setCategories(data)));
    }
}
 
export function deleteCategory(id) {
    
    return dispatch =>{
        return fetch(`${SERVICE_BASE}/api/v1/admin/categories/${id}`, {
            method: 'delete',            
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then(handleResponse)
        .then(data => dispatch(categoryDeleted(id))); 
    }
} 

export function saveCategory(data){

    return dispatch =>{
        return fetch(`${SERVICE_BASE}/api/v1/admin/categories`, {
            method: 'post',
            body: JSON.stringify(data),
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then(handleResponse)
        .then(data => dispatch(categorySaved(data.category))); 
    }
}

export function updateCategory(data){

    return dispatch => {
        return fetch(`${SERVICE_BASE}/api/v1/admin/categories/${data.id}`, {
            method: 'put',
            body: JSON.stringify(data),
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then(handleResponse)
        .then(data => dispatch(categoryUpdated(data.category))); 
    }
}


export function fetchCategory(categoryId) {
    
    return dispatch => {
        fetch(`${SERVICE_BASE}/api/v1/admin/categories/${categoryId}`)
            .then(res => res.json())  
            .then(data => dispatch(setCategory(data)));
    }
}