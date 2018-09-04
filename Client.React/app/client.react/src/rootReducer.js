import {combineReducers} from 'redux';

import articlesReducer from './reducers/articlesReducer';
import categoriesReducer from './reducers/categoriesReducer';
import commentsReducer from './reducers/commentsReducer';

export default combineReducers({
    articlesReducer,
    categoriesReducer,
    commentsReducer,
});