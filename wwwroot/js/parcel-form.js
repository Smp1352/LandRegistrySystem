// wwwroot/js/person-validation.js

$(document).ready(function () {
    // ==========================================
    // اعتبارسنجی کدملی در لحظه
    // ==========================================
    $('#NationalCode').on('blur', function () {
        var nationalCode = $(this).val().trim();

        if (nationalCode.length === 10) {
            // ✅ فقط وقتی 10 رقم کامل شده، جستجو کن
            $.ajax({
                url: '/Persons/Create?handler=SearchNationalCode',
                type: 'GET',
                data: { nationalCode: nationalCode },
                timeout: 5000,  // ✅ تنظیم Timeout
                success: function (response) {
         
                if (response.exists) {
                    // پر کردن فرم با اطلاعات پیدا شده
                    $('#FirstName').val(response.firstName);
                    $('#LastName').val(response.lastName);
                    $('#Mobile').val(response.mobile);
                    $('#Phone').val(response.phone);
                    $('#FatherName').val(response.fatherName);
                    $('#Address').val(response.address);
                    $('#Email').val(response.email);
                    $('#PostalCode').val(response.postalCode);

                    // غیرفعال کردن فیلدهای پر شده
                    $('#FirstName, #LastName, #Mobile, #Phone, #FatherName, #Address, #Email, #PostalCode')
                        .prop('readonly', true);

                    showSuccess('NationalCode', response.message);
                } else {
                    // فعال کردن فیلدها برای ثبت جدید
                    $('#FirstName, #LastName, #Mobile, #Phone, #FatherName, #Address, #Email, #PostalCode')
                        .prop('readonly', false);

                    showError('NationalCode', response.message);
                }
            },
            error: function () {
                showError('NationalCode', 'خطا در ارتباط با سرور');
            }
        });
    });

    // ==========================================
    // اعتبارسنجی شماره همراه
    // ==========================================
    $('#Mobile').on('blur', function () {
        var mobile = $(this).val().trim();
        if (mobile && !/^09\d{9}$/.test(mobile)) {
            showError('Mobile', 'شماره همراه باید با 09 شروع شود و 11 رقم باشد');
        } else {
            clearError('Mobile');
        }
    });

    // ==========================================
    // اعتبارسنجی ایمیل
    // ==========================================
    $('#Email').on('blur', function () {
        var email = $(this).val().trim();
        if (email && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
            showError('Email', 'ایمیل معتبر نیست');
        } else {
            clearError('Email');
        }
    });

    // ==========================================
    // اعتبارسنجی کد پستی
    // ==========================================
    $('#PostalCode').on('blur', function () {
        var postalCode = $(this).val().trim();
        if (postalCode && !/^\d{10}$/.test(postalCode)) {
            showError('PostalCode', 'کد پستی باید 10 رقم باشد');
        } else {
            clearError('PostalCode');
        }
    });

    // ==========================================
    // توابع کمکی
    // ==========================================
    function showError(fieldId, message) {
        var field = $('#' + fieldId);
        field.removeClass('is-valid').addClass('is-invalid');

        var errorSpan = field.siblings('.text-danger');
        if (errorSpan.length === 0) {
            field.after('<span class="text-danger field-validation-error">' + message + '</span>');
        } else {
            errorSpan.text(message);
        }

        // حذف پیام موفقیت قبلی
        field.siblings('.text-success').remove();
    }

    function showSuccess(fieldId, message) {
        var field = $('#' + fieldId);
        field.removeClass('is-invalid').addClass('is-valid');

        var successSpan = field.siblings('.text-success');
        if (successSpan.length === 0) {
            field.after('<span class="text-success">' + message + '</span>');
        } else {
            successSpan.text(message);
        }

        // حذف خطای قبلی
        field.siblings('.text-danger').remove();
    }

    function clearError(fieldId) {
        var field = $('#' + fieldId);
        field.removeClass('is-invalid is-valid');
        field.siblings('.text-danger').remove();
        field.siblings('.text-success').remove();
    }
});