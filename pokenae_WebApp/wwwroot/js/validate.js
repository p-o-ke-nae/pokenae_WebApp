//validateクラスをもつ全てのボタンに対して検証処理の実施を行わせる
document.addEventListener('DOMContentLoaded', function () {
    const validateButtons = document.querySelectorAll('.validate');
    validateButtons.forEach(button => {
        button.addEventListener('click', async function (event) {
            event.preventDefault(); // デフォルトのクリック動作を防ぐ
            event.stopImmediatePropagation(); // イベントの伝播を停止

            resetMessageArea();

            const currentPath = window.location.pathname;
            const verificationtoken = document.getElementsByName('__RequestVerificationToken')[0];

            if (verificationtoken) {
                const token = verificationtoken.value;

                const jsonObject = getFormData();

                // クライアント側の検証
                const clientErrors = validateFields();
                if (clientErrors.length > 0) {
                    showMessage(clientErrors, "Error");
                    highlightErrors(clientErrors);
                    return;
                }

                try {
                    // サーバー側の検証処理
                    const response = await fetch(`${currentPath}?handler=Validate`, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                            'RequestVerificationToken': token
                        },
                        body: JSON.stringify(jsonObject) // フォームデータをJSON形式で送信
                    });

                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }

                    const data = await response.json();
                    if (data.errors && data.errors.length > 0) {
                        showMessage(data.errors, "Error");
                        highlightErrors(data.errors);
                    } else {
                        // 検証が成功した場合、元のクリックイベントをトリガー
                        button.removeEventListener('click', arguments.callee); // 一時的にイベントリスナーを削除
                        button.click(); // 元のクリックイベントをトリガー
                        button.addEventListener('click', arguments.callee); // イベントリスナーを再度追加
                    }
                } catch (error) {
                    console.error('There has been a problem with your fetch operation:', error);
                }
            }
        });
    });

    function validateFields() {
        const errors = [];
        const requiredFields = document.querySelectorAll('[required]');
        requiredFields.forEach(field => {
            if (!field.value.trim()) {
                const fieldName = field.getAttribute('name');
                errors.push(`The ${fieldName} field is required.`);
            }
        });

        const stringLengthFields = document.querySelectorAll('[data-val-length-max], [data-val-length-min]');
        stringLengthFields.forEach(field => {
            const fieldName = field.getAttribute('name');
            const value = field.value.trim();
            const maxLength = field.getAttribute('data-val-length-max');
            const minLength = field.getAttribute('data-val-length-min');

            if (maxLength && value.length > maxLength) {
                errors.push(`The ${fieldName} field must be at most ${maxLength} characters long.`);
            }
            if (minLength && value.length < minLength) {
                errors.push(`The ${fieldName} field must be at least ${minLength} characters long.`);
            }
        });

        const rangeFields = document.querySelectorAll('[data-val-range-max], [data-val-range-min]');
        rangeFields.forEach(field => {
            const fieldName = field.getAttribute('name');
            const value = parseFloat(field.value.trim());
            const maxValue = parseFloat(field.getAttribute('data-val-range-max'));
            const minValue = parseFloat(field.getAttribute('data-val-range-min'));

            if (!isNaN(maxValue) && value > maxValue) {
                errors.push(`The ${fieldName} field must be at most ${maxValue}.`);
            }
            if (!isNaN(minValue) && value < minValue) {
                errors.push(`The ${fieldName} field must be at least ${minValue}.`);
            }
        });

        return errors;
    }

    function highlightErrors(errors) {
        // すべてのエラーメッセージをクリア
        const errorFields = document.querySelectorAll('.error');
        errorFields.forEach(field => {
            field.classList.remove('error');
        });

        // エラーメッセージを表示し、該当するフィールドを強調表示
        errors.forEach(error => {
            const fieldName = error.split(' ')[1]; // エラーメッセージからフィールド名を抽出
            const field = document.querySelector(`[name$="${fieldName}"]`);
            if (field) {
                field.classList.add('error');
                field.addEventListener('focus', removeErrorClass);
                field.addEventListener('blur', removeErrorClass);
            }
        });
    }

    function removeErrorClass(event) {
        event.target.classList.remove('error');
        event.target.removeEventListener('focus', removeErrorClass);
        event.target.removeEventListener('blur', removeErrorClass);
    }

});
