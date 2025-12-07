import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/widgets/custom_button.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/data/implementation/offline_data_source_impl.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class UploadAttachmentsWidget extends StatefulWidget {
  final String pdfIconPath;
  final String downloadIconPath;
  final String uploadButtonImagePath;
  final String prefixText;
  final String submitText;
  final String titleText;
  final VoidCallback? onSubmit;

  final String? fieldText;
  final TextEditingController? controller;

  const UploadAttachmentsWidget({
    super.key,
    required this.pdfIconPath,
    required this.downloadIconPath,
    required this.uploadButtonImagePath,
    required this.prefixText,
    required this.submitText,
    required this.titleText,
    this.onSubmit,
    this.fieldText,
    this.controller,
  });

  @override
  State<UploadAttachmentsWidget> createState() =>
      _UploadAttachmentsWidgetState();
}

class _UploadAttachmentsWidgetState extends State<UploadAttachmentsWidget> {
  late TextEditingController textController;

  @override
  void initState() {
    super.initState();
    textController = widget.controller ?? TextEditingController();

    if (widget.fieldText != null) {
      textController.text = widget.fieldText!;
    }
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Align(
          alignment: Alignment.centerRight,
          child: Text(
            widget.titleText,
            style: MyFonts.styleMedium500_16.copyWith(color: MyColors.black),
          ),
        ),
        SizedBox(height: 6.h),
        SizedBox(
          width: 398.w,
          height: 64.h,
          child: Stack(
            children: [
              CustomTextFormField(
                controller: textController,
                readOnly: true,
                showCursor: false,
                prefix: Row(
                  children: [
                    Image.asset(
                      widget.pdfIconPath,
                      width: 24.w,
                      height: 24.h,
                      fit: BoxFit.contain,
                    ),
                    SizedBox(width: 12.w),
                    Text(
                      widget.prefixText,
                      style: MyFonts.semiBold600_18.copyWith(
                        color: MyColors.black,
                      ),
                    ),
                  ],
                ),
                suffix: SizedBox(width: 36.w),
              ),
              Positioned(
                left: 8.w,
                top: 0,
                bottom: 0,
                child: Align(
                  alignment: const Alignment(-0.9, -0.3),
                  child: InkWell(
                    onTap: () async {
                      final dataSource = OfflineDataSourceImpl();
                      await dataSource.handleFileDownload(context);
                    },
                    child: Image.asset(
                      widget.downloadIconPath,
                      width: 24.w,
                      height: 24.h,
                      fit: BoxFit.contain,
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
        SizedBox(height: 20.h),
        InkWell(
          onTap: () async {
            final dataSource = OfflineDataSourceImpl();
            dataSource.handleFileUpload(context);
          },
          child: Image.asset(
            widget.uploadButtonImagePath,
            width: 398.w,
            height: 58.h,
            fit: BoxFit.fill,
          ),
        ),
        SizedBox(height: 48.h),
        SizedBox(
          width: 400.w,
          height: 58.h,
          child: CustomButton(
            txt: widget.submitText,
            onPressed: widget.onSubmit,
          ),
        ),
      ],
    );
  }
}
