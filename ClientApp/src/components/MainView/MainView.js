import React, { useState} from "react";

import Form from "../Form/Form";
import Chat from "../Chat/Chat";
import "./MainView.css";

const MainView = () => {
    const [formData, setFormData] = useState({
        firstname: "",
        lastname: "",
        email: "",
        reasonOfContact: "",
        urgency: null,
    });

    return (
        <div className="main-view-container">
            <div className="form-section">
                <Form formData={formData} setFormData={setFormData} />
            </div>
            <div className="chat-section">
                <Chat formData={formData} setFormData={setFormData} />
            </div>
        </div>
    );
};

export default MainView;