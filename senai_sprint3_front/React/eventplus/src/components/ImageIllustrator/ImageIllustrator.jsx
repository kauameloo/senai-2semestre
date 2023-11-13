import React from 'react';
import './ImageIllustrator.css'

import imageDefault from '../../assets/images/default-image.jpeg'
const ImageIllustrator = ({ alterText, imageRender = imageDefault, additionalClass = '' }) => {
    return (
        <div>
            <figure className='illustrator-box'>
                <img
                    src={imageRender}
                    alt={alterText}
                    className={`illustrator-box__image ${additionalClass}`}
                />
            </figure>
        </div>
    );
};

export default ImageIllustrator;