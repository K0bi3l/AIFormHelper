import React, { useState } from "react";
import "./Form.css"; // 🔗 Import arkusza CSS

const Form = () => {
    const [formData, setFormData] = useState({
        firstname: "",
        lastname: "",
        email: "",
        reason: "",
        urgency: 5,
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prev) => ({
            ...prev,
            [name]: name === "urgency" ? parseInt(value) : value,
        }));
    };

    const validateEmail = (email) => {
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!emailPattern.test(email)) {
            alert("Invalid email format");
            return false;
        }

        return true;
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        if (!validateEmail(formData.email)) {
            return;
        }

        console.log("Form submitted:", formData);
    };

    

    return (
        <div className="form-container">
            <h2 className="form-heading">Contact Form</h2>
            <form onSubmit={handleSubmit} className="form">
                <div className="form-group">
                    <label>Firstname:</label>
                    <input
                        type="text"
                        name="firstname"
                        maxLength="20"
                        value={formData.firstname}
                        onChange={handleChange}
                        required
                    />
                </div>

                <div className="form-group">
                    <label>Lastname:</label>
                    <input
                        type="text"
                        name="lastname"
                        maxLength="20"
                        value={formData.lastname}
                        onChange={handleChange}
                        required
                    />
                </div>

                <div className="form-group">
                    <label>Email:</label>
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                </div>

                <div className="form-group">
                    <label>Reason of Contact:</label>
                    <textarea
                        type="text"
                        name="reason"
                        maxLength="100"
                        value={formData.reason}
                        onChange={handleChange}
                        required
                    />
                </div>

                <div className="form-group">
                    <label>Urgency (1–10):</label>
                    <input
                        type="number"
                        name="urgency"
                        min="1"
                        max="10"
                        value={formData.urgency}
                        onChange={handleChange}
                        required
                    />
                </div>

                <button type="submit" className="form-button">Submit</button>
            </form>
        </div>
    );
};

export default Form;
