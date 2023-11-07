import React, { useState } from "react";
import './LoginForm.css';

const nullValues = [null, undefined, ""];
const getError = (value, fieldName = "") => {
    let field = nullValues.includes(fieldName) ? "This field" : fieldName;
    if (nullValues.includes(value.trim())) {
        return `${field} is required`;
    }
    return "";
};

const LoginForm = (props) => {
    const [userDetails, setUserDetails] = useState({
        username: "",
        password: "",
    });
    const [errors, setErrors] = useState({
        username: "",
        password: "",
    });

    const handleSubmit = (event) => {
        event.preventDefault();

        if (
            !nullValues.includes(userDetails.username.trim()) &&
            !nullValues.includes(userDetails.password.trim())
        ) {
            props.onSubmit({
                login: userDetails.username,
                password: userDetails.password,
            });
            setUserDetails({
                username: "",
                password: "",
            });
            setErrors({
                username: "",
                password: "",
            });
        } else {
            setErrors({
                ...errors,
                username: getError(userDetails.username, "Username"),
                password: getError(userDetails.password, "Password"),
            });
        }
    };

    const handleChange = (field, value) => {
        setUserDetails({ ...userDetails, [field]: value });
    };


    return (
        <form className="form">
            <h1>Login</h1>
            <label htmlFor="name">Name</label>
            <input
                type="text"
                id="name"
                value={userDetails.username}
                onChange={(e) => handleChange("username", e.target.value)}
            />
            <label htmlFor="password">Password</label>
            <input
                type="password"
                id="password"
                value={userDetails.password}
                onChange={(e) => handleChange("password", e.target.value)}
            />
            {!nullValues.includes(errors.username) && (
                <span className="error-text">{errors.username}</span>
            )}
            {!nullValues.includes(errors.password) && (
                <span className="error-text">{errors.password}</span>
            )}
            <button type="submit" onClick={handleSubmit}>
                Continue
            </button>
        </form>
    );
};

export default LoginForm;