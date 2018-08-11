import React from 'react';

class EditUser extends React.Component {
    render() {
        return (
            <form  >
                <div className="text-danger"></div>
                <div className="form-group">
                    <input type="hidden" />
                </div>
                <div className="form-group">
                    <label className="control-label">Email</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="form-group">
                    <label className="control-label">Год рождения</label>
                    <input type="text" className="datepicker form-control" />
                </div>
                <div className="form-group">
                    <input type="submit" value="Сохранить" className="btn btn-default" />
                </div>
            </form>
        )
    }
}

export default EditUser;