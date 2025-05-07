import React from "react";
import Form from "../Form/Form";
import Chat from "../Chat/Chat";
import "./MainView.css";

const MainView = () => {
    return (
        <div className="main-view-container">
            <div className="form-section">
                <Form />
            </div>
            <div className="chat-section">
                <Chat />
            </div>
        </div>
    );
};

export default MainView;