import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/features/leaves/widgets/build_leave_type_form_field.dart';
import 'package:athr_hr/features/leaves/widgets/build_optional_note.dart';
import 'package:athr_hr/features/leaves/widgets/upload_attachments.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class LeaveRequestWidget extends StatefulWidget {

  const LeaveRequestWidget({super.key,});

  @override
  State<LeaveRequestWidget> createState() => _LeaveRequestWidgetState();
}

class _LeaveRequestWidgetState extends State<LeaveRequestWidget> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: SingleChildScrollView(
          child: Padding(
            padding: EdgeInsets.all(16.sp),
            child: Column(
              children: [
                SizedBox(height: 10.h),
                CustomAppBarRow(
                  title: context.translate(LangKeys.createRequest),
                  trailing: Image.asset(
                    Assets.imagesArrow,
                    width: 24.w,
                    height: 24.h,
                    fit: BoxFit.contain,
                  ),
                  onPressed: (){
                    Navigator.pop(context);
                  },
                ),
                SizedBox(height: 36.h),
                BuildLeaveTypeFormField(),
                BuildOptionalNote(
                  titleText: context.translate(LangKeys.noteOptional),
                  hintText: context.translate(LangKeys.generalNote),
                ),
                SizedBox(height: 24.h,),
                UploadAttachmentsWidget(
                  pdfIconPath: Assets.imagesPdffile,
                  downloadIconPath: Assets.imagesDownloadpdf,
                  uploadButtonImagePath: Assets.imagesAttachmentsbutton,
                  prefixText: context.translate(LangKeys.medicalConsultation),
                  submitText:context.translate(LangKeys.submitRequest),
                  titleText:  context.translate(LangKeys.attachments),
                ),
                SizedBox(height: 20.h,),
              ],
            ),
          ),
        ),
    );
  }
}
